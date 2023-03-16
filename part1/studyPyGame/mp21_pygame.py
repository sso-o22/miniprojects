import pygame

pygame.init()
win = pygame.display.set_mode((1000, 500))

bg_img = pygame.image.load('./studyPyGame/Assets/background.png')
BG= pygame.transform.scale(bg_img, (1000, 500))  # 스케일업(창에 맞게 사진 사이즈 늘리기)
pygame.display.set_caption('게임 만들기')
icon = pygame.image.load('./studyPyGame/game.png')
pygame.display.set_icon(icon)

width = 1000
loop = 0
run = True
while run:
    win.fill((0, 0, 0))

    # 이벤트 = 시그널
    for event in pygame.event.get():  # 2. 이벤트 받기
        if event.type == pygame.QUIT:
            run = False

    # 배경을 그림
    win.blit(BG, (loop, 0))
    win.blit(BG, (width + loop, 0))
    if loop == -width:  # -1000
        loop = 0

    loop -= 1

    pygame.display.update()
