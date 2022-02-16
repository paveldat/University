from PIL import Image
import numpy as np

def count_dimension(image):
    length, width = im.size[0], im.size[1]
    # Словарь, где ключ - eps, а значение - тройка: (N(eps), ln(N(eps), ln(eps))
    e = {2: [0, 0, 0], 4: [0, 0, 0], 8: [0, 0, 0], 16: [0, 0, 0], 32: [0, 0, 0], 64: [0, 0, 0]}
    # Итоерируемся по ключам
    for e_i in e:
        # Итерируемся по ячейкам
        for i in range(0, im.size[0]//e_i):
            for j in range(0, im.size[1]//e_i):
                found_black = False
                # Итерируемся по элементам ячейки
                for k in range(i*e_i, ((i+1)*e_i) - 1):
                    for l in range(j*e_i, ((j+1)*e_i) - 1):
                        if image.getpixel((k,l)) == 0:
                            found_black = True
                if found_black:
                    e[e_i][0] += 1
        # Запоминаем ln(N(eps))
        e[e_i][1] = np.log(e[e_i][0])
        # Запоминаем ln(eps)
        e[e_i][2] = np.log(e_i)
    # Список значений ln(eps)
    ln_e_list = [e[x][2] for x in e]
    # Список значений ln(N(eps))
    ln_n_e_list = [e[x][1] for x in e]
    # Вызов МНК
    return -np.polyfit(ln_e_list, ln_n_e_list, 1)[0]

def convert_image(image, converted_file_name):
    black_and_white = image.convert('1')
    black_and_white.save(converted_file_name)
    return black_and_white


if __name__ == '__main__':
    finished = False
    while not finished:
        print("Please, type the name of the file. Or press enter to skip. Default name is image.jpg")
        name = input()
        if not name:
            name = 'image.jpg'
        try:
            im = Image.open(name)
            # Переводим изображение в черно-белый вид
            im = convert_image(im, 'inverted_' + name)
            print(f"Size of your image is {im.size[0]} x {im.size[1]}")
            dim = count_dimension(im)
            print(f"Dimension of your image is {dim}")
            finished = True
        except Exception as e:
            print(e)
            print("Could not find the file. Please try again.")