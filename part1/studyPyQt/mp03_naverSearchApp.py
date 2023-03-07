# Gt Designer 디자인 사용
import sys
from PyQt5 import uic
from PyQt5.QtWidgets import *
from NaverApi import *

class qtApp(QWidget):

    def __init__(self):
        super().__init__()
        uic.loadUi('./studyPyQt/naverApiSearch.ui', self)

        # 검색 버튼 클릭 시그널 / 슬롯함수
        self.btnSearch.clicked.connect(self.btnSearchClicked) 
        # 검색어 입력 후 엔터를 치면 처리
        self.txtSearch.returnPressed.connect(self.txtSearchReturned) 

    def txtSearchReturned(self):
        self.btnSearchClicked()

    def btnSearchClicked(self):
        search = self.txtSearch.text()

        if search == '':
            QMessageBox.warning(self, '경고', '검색어를 입력하세요!')  # warning 안하고 about하면 아이콘 안뜸
            return
        else:
            api = NaverApi()  # NaverApi 클래스 객체
            node = 'news'  # movie로 변경하면 영화검색
            outputs = []  # 결과 담을 리스트 변수
            display = 100  # 검색결과 몇개 출력할건지

            result = api.get_naver_search(node, search, 1, display)
            # print(result)
            # QMessageBox.about(self, 'result', result) 결과가 너무 많아서 큐메시지박스에 못씀
            # 리스트뷰에 출력 기능
            while result != None and result['display'] != 0:
                for post in result['items']:  # 100개의 post
                    api.get_post_data(post, outputs)  # NaverApi 클래스에서 처리

if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = qtApp()
    ex.show()
    sys.exit(app.exec_())