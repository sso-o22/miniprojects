# 이메일 보내기 앱
import smtplib  # Simple Mail Transfer Protocol 메일 전송 프로토콜
from email.mime.text import MIMEText  # Multipurpose Interner Mail Extensions

send_email = 'sso-o22@naver.com'
send_pass = ''

recv_email = 'jung7bong7@naver.com'

smtp_name = 'smtp.naver.com'
smtp_port = 587  # 포트번호 = 버스 노선

text = '''메일 내용입니다. 긴급입니다.
조심하세요~ 빨리 연락주세요!!
'''
msg = MIMEText(text)
msg['Subject'] = '메일 제목입니다'
msg['From'] = send_email  # 보내는 사람
msg['To'] = recv_email  # 받는 사람
print(msg.as_string())

mail = smtplib.SMTP(smtp_name, smtp_port)  # SMTP 객체 생성
mail.starttls()  # 전송계층 보안 시작
mail.login(send_email, send_pass)
mail.sendmail(send_email, recv_email, msg=msg.as_string())
mail.quit()
print('전송완료!')
