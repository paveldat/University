from PIL import Image, ImageDraw
import numpy as np

delta = [1, 2]
CELL_SIZE = 20

def convert_image(image, converted_file_name):
    black_and_white = image.convert('1')
    black_and_white.save(converted_file_name)
    return black_and_white

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
    
    return A[delta[-1]]

def build_segmentation(image, save_file_name):
    length, width = image.size[0], image.size[1]
    cell_length, cell_width = length//CELL_SIZE, width//CELL_SIZE
    A = np.zeros((cell_length, cell_width))
    for i in range(0, cell_length):
        for j in range(0, cell_width):
            area = (i*CELL_SIZE, j*CELL_SIZE, (i+1)*CELL_SIZE, (j+1)*CELL_SIZE)
            cell = image.crop(area)
            A[i][j] = get_A(cell, delta)
    
    mean = np.mean(A)

    new_image = Image.new("L", (cell_length*CELL_SIZE, cell_width*CELL_SIZE))
    img1 = ImageDraw.Draw(new_image)

    for i in range(0, cell_length):
        for j in range(0, cell_width):
            if A[i][j] < mean:
                img1.rectangle([(i*CELL_SIZE, j*CELL_SIZE), ((i+1)*CELL_SIZE, (j+1)*CELL_SIZE)], fill = "white", outline="white")
            else:
                img1.rectangle([(i*CELL_SIZE, j*CELL_SIZE), ((i+1)*CELL_SIZE, (j+1)*CELL_SIZE)], fill = "black", outline="black")
    new_image.save(save_file_name)


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
            segmentated_name = "segmentated_" + name
            build_segmentation(im, segmentated_name)
            print(f"Sermentated image is built. File name is {segmentated_name}")
            finished = True
        except Exception as e:
            print(e)
            print("Could not find the file. Please try again.")