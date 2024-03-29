# 전국 대학교 리스트
# pip install pandas

import pandas as pd

filePath = './studyPython/university_list_2020.xlsx'
df_excel = pd.read_excel(filePath, engine='openpyxl')
df_excel.columns = df_excel.loc[4].tolist()
df_excel = df_excel.drop(index=list(range(0, 5)))  # 실제 데이터 이외 행을 날려버림 (필요없는 부분 삭제)

print(df_excel.head())  # 상위 5개만 출력

print(df_excel['학교명'].values)  # 학교명 컬럼만 출력
print(df_excel['주소'].values)  # 주소 컬럼만 출력