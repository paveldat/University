from PIL import Image
import numpy as np


if __name__ == '__main__':
    finished = False
    while not finished:
        print("Please, type the name of the file. Or press enter to skip. Default name is image.jpg\n")
        name = input()
        if not name:
            name = 'image.jpg'
        try:
            im = Image.open(name)
            finished = True
        except Exception as e:
            print(e)
            print("Could not find the file. Please try again.\n")
    

    converted = im.convert("L")
    converted.save('result.png')