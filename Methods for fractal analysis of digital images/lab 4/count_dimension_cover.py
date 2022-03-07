from PIL import Image
import numpy as np

CELL_SIZE = 32
delta = [1, 2]

def get_A(cell, ds):
    length, width = cell.size[0], cell.size[1]
    u = np.zeros((len(ds) + 1, length + 1, width + 1))
    b = np.zeros((len(ds) + 1, length + 1, width + 1))
    v = np.zeros((len(ds) + 1))
    A = np.zeros((len(ds) + 1))

    for i in range(0, length):
        for j in range(0, width):
            u[0][i][j] = cell.getpixel((i, j))
            b[0][i][j] = cell.getpixel((i, j))

            for d in ds:
                u[d][i][j] = max(u[d - 1][i][j] + 1, max(u[d - 1][i + 1][j + 1], u[d - 1][i - 1][j + 1], u[d - 1][i + 1][j - 1], u[d - 1][i - 1][j - 1]))
                b[d][i][j] = min(b[d - 1][i][j] - 1, min(b[d - 1][i + 1][j + 1], b[d - 1][i - 1][j + 1], b[d - 1][i + 1][j - 1], b[d - 1][i - 1][j - 1]))
    
    for d in ds:
        v[d] = 0
        for i in range(0, length):
            for j in range(0, width):
                v[d] += u[d][i][j] - b[d][i][j]
    
    for d in ds:
        A[d] = (v[d] - v[d-1]) / 2
    
    return A


def count_dimension_cover(image):
    length, width = image.size[0], image.size[1]
    cell_length, cell_width = length//CELL_SIZE, width//CELL_SIZE
    A = np.zeros((cell_length, cell_width, len(delta)+1))
    for i in range(0, cell_length):
        for j in range(0, cell_width):
            area = (i*CELL_SIZE, j*CELL_SIZE, (i+1)*CELL_SIZE, (j+1)*CELL_SIZE)
            cell = image.crop(area)
            for d in delta:
                A[i][j][d] = get_A(cell, delta)[d]

    
    As = []
    for d in delta:
        s = 0
        for i in range(0, cell_length):
            for j in range(0, cell_width):
                s += A[i][j][d]
        As.append(s)
        
    return 2 - np.polyfit(np.log(As), np.log(delta), 1)[0] * (-1)

def convert_image(image, converted_file_name):
    black_and_white = image.convert('L')
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
            dim = count_dimension_cover(im)
            print(f"Dimension of your image is {dim}")
            finished = True

        except Exception as e:
            print(e)
            print("Could not find the file. Please try again.")
