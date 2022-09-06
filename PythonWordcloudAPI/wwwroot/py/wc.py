from wordcloud_fa import WordCloudFa
import sys

text = sys.argv[1];

wordcloud = WordCloudFa(background_color="white").generate(text)

image = wordcloud.to_image()
image.save('wwwroot/image/persian-example.png')

print(text)