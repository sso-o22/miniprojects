import sys
from PyQt5 import uic
from PyQt5.QtWidgets import *
from PyQt5.QtGui import *  # QIcon은 여기 있음
import pymysql
import math

class qtApp(QWidget):
    def __init__(self):
        super().__init__()
        uic.loadUi('./studyPyQt/calculator.ui', self)
        self.setWindowTitle('계산기 v0.1')
        # 시그널 16개의 슬롯함수는 1개(btnClicked)
        self.btn_C.clicked.connect(self.btnClicked)
        self.btn_number0.clicked.connect(self.btnClicked)
        self.btn_number1.clicked.connect(self.btnClicked)
        self.btn_number2.clicked.connect(self.btnClicked)
        self.btn_number3.clicked.connect(self.btnClicked)
        self.btn_number4.clicked.connect(self.btnClicked)
        self.btn_number5.clicked.connect(self.btnClicked)
        self.btn_number6.clicked.connect(self.btnClicked)
        self.btn_number7.clicked.connect(self.btnClicked)
        self.btn_number8.clicked.connect(self.btnClicked)
        self.btn_number9.clicked.connect(self.btnClicked)
        self.btn_result.clicked.connect(self.btnClicked)
        self.btn_minus.clicked.connect(self.btnClicked)
        self.btn_add.clicked.connect(self.btnClicked)
        self.btn_multipy.clicked.connect(self.btnClicked)
        self.btn_divide.clicked.connect(self.btnClicked)

        self.txt_view.setEnabled(False)
        self.text_value = ''

    def btnClicked(self):
        btn_val = self.sender().text()
        if btn_val == 'C':  # clear
            print('clear')
            self.txt_view.setText('0')
            self.text_value = ''
        elif btn_val == '=':  # 계산 결과
            print('=')
            try:
                result = eval(self.text_value.lstrip('0'))
                print(round(result, 4))  # ex) 10 / 6
                self.txt_view.setText(str(round(result, 4)))
            except:
                self.txt_view.setText('ERROR')
        else:
            if btn_val == 'X':  # 영어 문자이므로 기능있는 *로 바꿔줘야 함
                btn_val = '*'
            self.text_value += btn_val  # 터미널에 연달에 입력되도록 -> 수식 완성되어서 계산 가능
            print(self.text_value)
            self.txt_view.setText(self.text_value)  # 버튼 누르는 것들 계산기창에 표시

if __name__ == '__main__':
    app = QApplication(sys.argv)
    ex = qtApp()
    ex.show()
    sys.exit(app.exec_())
