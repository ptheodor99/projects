import requests
import tkinter as tk
import pandas as pd
from bs4 import BeautifulSoup
from matplotlib import pyplot as plt
from tkinter import filedialog

url = "https://www.asos.com/women/jewellery/cat/?cid=4175&nlid=ww|accessories|shop+by+product|jewellery+"
headers = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36"
    }

def retrieve_product_names(): 
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.content, "html.parser")
    product_names = []
    products = soup.find_all("div", class_="overflowFade_zrNEl")
    for product in products:
        product_names.append(product.text.strip())
    return product_names


def retrieve_product_prices():
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.content, "html.parser")
    product_prices = []
    prices = soup.find_all("span", class_="price_CMH3V")
    for price in prices:
        price_str = price.text.strip()
        if(price_str[0] == '\u00A3'):
            price_str = '\u20AC' + price_str[1:]
        product_prices.append(price_str)
    return product_prices
    
def create_graph(product_names, product_prices):
    fig, ax = plt.subplots(figsize=(15, 8))
    ax.bar(product_names, product_prices)
    ax.set_xlabel("Product Names")
    ax.set_ylabel("Product Prices")
    ax.set_title("Product Prices Chart")
    ax.tick_params(axis='x', labelrotation=45) 
    plt.show()

def display_matrix(product_names, product_prices):
    pd.set_option('display.max_rows', None)
    matrix = pd.DataFrame({"Product Names": product_names, "Product Prices": product_prices})
    print(matrix) 

def save_to_excel(product_names, product_prices, filename):
    matrix = pd.DataFrame({"Product Names": product_names, "Product Prices": product_prices})
    
    filetypes = [("Excel Files", ".xlsx"), ("All Files", "*.*")]
    file_path = filedialog.asksaveasfilename(defaultextension=".xlsx", initialfile=filename, filetypes=filetypes)
    
    if file_path:
        if not file_path.endswith(".xlsx"):
            file_path += ".xlsx"
        matrix.to_excel(file_path, index=True)
        print(f"Matrix saved to {file_path}")
        
def button_click(event):
    if event.widget == retrieve_btn:
        product_names = retrieve_product_names()
        product_prices = retrieve_product_prices()
        products_matrix = pd.DataFrame({"Product Names": product_names, "Product Prices": product_prices})
        matrix_text.delete("1.0", tk.END)
        matrix_text.insert(tk.END, products_matrix.to_string(index=True))
    elif event.widget == graph_btn:
        product_names = retrieve_product_names()
        product_prices = retrieve_product_prices()
        create_graph(product_names, product_prices)
    elif event.widget == matrix_btn:
        product_names = retrieve_product_names()
        product_prices = retrieve_product_prices()
        display_matrix(product_names, product_prices)
    elif event.widget == save_btn:
        product_names = retrieve_product_names()
        product_prices = retrieve_product_prices()
        filename = filename_entry.get()
        save_to_excel(product_names, product_prices, filename)


   
 
window = tk.Tk()
window.title("E-commerce Data")

filename_label = tk.Label(window, text="Enter Excel Filename:")
filename_label.pack()

filename_entry = tk.Entry(window)
filename_entry.pack()

retrieve_btn = tk.Button(window, text="Retrieve Data")
retrieve_btn.pack()

graph_btn = tk.Button(window, text="Create Graph")
graph_btn.pack()

matrix_btn = tk.Button(window, text="Display Matrix")
matrix_btn.pack()

save_btn = tk.Button(window, text="Save to Excel File")
save_btn.pack()

retrieve_btn.bind("<Button-1>", button_click)
graph_btn.bind("<Button-1>", button_click)
matrix_btn.bind("<Button-1>", button_click)
save_btn.bind("<Button-1>", button_click)

matrix_text = tk.Text(window, height=50, width=250)
matrix_text.pack()

window.mainloop()