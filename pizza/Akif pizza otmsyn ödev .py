print("hello world")

#cemalakif özateş dc name->(salffev#4255) tarafından yapılmıştır, bu proje global ai hub tarafından yapılan akbank python bootcamp eğitimi için hazırlanan bir çeşit pizza sipariş otomasyonudur.
#buradaki pizza otomasyonunda kısaca yaptıklarımı açıklayayım;
#öncelikle 5çeşit pizza, 7çeşit ekstra malzeme ve 7çeşitden içeceklerden oluşan bir dizi menü bloğu,
#ardından bu sistem için basit bir admin giriş kısmını oluşturdum ve kullancı tarafınıda bu kısımdan sonrasına dahil ettim.
#adisyon için sipariş sonrasında verilen siparişi görüntülemek için txt dosyasına sipaiş aktarımında bulundum ki bu adisyonu göstermek için yaptığım bi kısım.
#en son olarak tüm bu yazdığım bloklar için basit bir arayüz yazdım.

#menü listesi.
class MenuItem:
    def __init__(self, name, price):
        self.name = name
        self.price = price


class Menu:
    def __init__(self):
        self.pizzas = [
            MenuItem("Margaritalı", 101),
            MenuItem("Peperoni", 102),
            MenuItem("kıymalı", 103),
            MenuItem("Barbekü", 104),
            MenuItem("domatesli", 105)
        ]
        self.extras = [
            MenuItem("Zeytin", 5),
            MenuItem("Mantar", 7),
            MenuItem("Kaşar", 5),
            MenuItem("Soğan", 7),
            MenuItem("Mısır", 5),
            MenuItem("Jambon", 7),
            MenuItem("Sos", 5)
        ]
        self.drinks = [
            MenuItem("Kola", 15),
            MenuItem("Soğukçay", 15),
            MenuItem("Gazoz", 15),
            MenuItem("Fanta", 15),
            MenuItem("şerbet", 15),
            MenuItem("limonata", 15),
            MenuItem("Ayran", 15)
        ]


class Order:
    def __init__(self, customer_name, phone_number, address):
        self.customer_name = customer_name
        self.phone_number = phone_number
        self.address = address
        self.items = []
        self.total_price = 0

    def add_item(self, item):
        self.items.append(item)
        self.total_price += item.price


class PizzaOrder:
    def __init__(self):
        self.menu = Menu()
        self.order = None

    def show_menu(self):
        print("\nNe sipariş etmek istersiniz?\n1. Pizza Çeşitleri\n2. Ekstra Malzemeler\n3. İçecekler\n4. Siparişi Tamamla\n5. Çıkış")

    def show_pizzas(self):
        print("\nPizza Çeşitleri:")
        for index, pizza in enumerate(self.menu.pizzas):
            print(f"{index+1}. {pizza.name} - {pizza.price} TL")

    def show_extras(self):
        print("\nEkstra Malzemeler:")
        for index, extra in enumerate(self.menu.extras):
            print(f"{index+1}. {extra.name} - {extra.price} TL")

    def show_drinks(self):
        print("\nİçecekler:")
        for index, drink in enumerate(self.menu.drinks):
            print(f"{index+1}. {drink.name} - {drink.price} TL")

    def get_customer_details(self):
        customer_name = input("İsim soyisim: ")
        phone_number = input("Telefon numarası: ")
        address = input("Adres: ")
        self.order = Order(customer_name, phone_number, address)

    def take_order(self):
        while True:
            self.show_menu()
            choice = input("Seçiminiz: ")
            if choice == "1":
                self.show_pizzas()
                pizza_choice = int(input("Hangi pizzayı istersiniz?: "))
                pizza = self.menu.pizzas[pizza_choice - 1]
                self.order.add_item(pizza)
            elif choice == "2":
                self.show_extras()
                extra_choice = int(input("Hangi ekstraları istersiniz?: "))
                extra = self.menu.extras[extra_choice - 1]
                self.order.add

#admin giriş şifre vs...

import hashlib

# Şifreleme işlemi

def encrypt_string(hash_string):
    sha_signature = hashlib.sha256(hash_string.encode()).hexdigest()
    return sha_signature

# Admin parolası

admin_password = "12345"

# Şifrelenmiş parola

hashed_password = encrypt_string(admin_password)

# Parola doğrulama

def verify_password(input_password):
    if encrypt_string(input_password) == hashed_password:
        return True
    else:
        return False

# Kullanıcıdan parola isteme ve doğrulama

user_input = input("Lütfen parolanızı girin: ")
if verify_password(user_input):
    print("Parola doğru! Admin olarak giriş yapıldı.")
    # Burada admin için gerekli işlemler yapılabilir

else:
    print("Parola yanlış! Admin olarak giriş yapılamadı.")

#adisyon için verilen sipariş bilgilerini txt dosyası ataması

import datetime

class PizzaOrderApp(QWidget):
    ...

    def save_order(self):
        filename = f"{datetime.datetime.now().strftime('%Y%m%d_%H%M%S')}.txt"
        with open(filename, "w") as f:
            for idx, item in enumerate(self.order):
                if item in self.pizzas:
                    f.write(f"{idx+1}. Pizza - {item} - {self.pizzas[item]} TL\n")
                elif item in self.extras:
                    f.write(f"{idx+1}. Ekstra - {item} - {self.extras[item]} TL\n")
                elif item in self.drinks:
                    f.write(f"{idx+1}. İçecek - {item} - {self.drinks[item]} TL\n")
            f.write(f"Toplam Tutar: {self.total_price} TL\n")
            f.write(f"Ad-Soyad: {self.name_input.text()}\n")
            f.write(f"Telefon: {self.phone_input.text()}\n")
            f.write(f"Adres: {self.address_input.text()}\n")
            f.write(f"Tarih: {datetime.datetime.now().strftime('%d-%m-%Y %H:%M:%S')}\n")

#otomasyonun arayüz kısmı buradan sonrası.

from PyQt5.QtWidgets import QApplication, QWidget, QVBoxLayout, QHBoxLayout, QLabel, QLineEdit, QPushButton, QTextEdit

class PizzaOrderApp(QWidget):
    def __init__(self):
        super().__init__()

        # Başlık
        self.setWindowTitle("Pizza Sipariş Uygulaması")

        # Düzen
        layout = QVBoxLayout()

        # İsim
        name_layout = QHBoxLayout()
        name_label = QLabel("Ad Soyad:")
        self.name_input = QLineEdit()
        name_layout.addWidget(name_label)
        name_layout.addWidget(self.name_input)

        # Telefon
        phone_layout = QHBoxLayout()
        phone_label = QLabel("Telefon:")
        self.phone_input = QLineEdit()
        phone_layout.addWidget(phone_label)
        phone_layout.addWidget(self.phone_input)

        # Adres
        address_layout = QHBoxLayout()
        address_label = QLabel("Adres:")
        self.address_input = QLineEdit()
        address_layout.addWidget(address_label)
        address_layout.addWidget(self.address_input)

        # Sipariş Listesi
        order_label = QLabel("Sipariş Listesi:")
        self.order_list = QTextEdit()

        # Butonlar
        button_layout = QHBoxLayout()
        add_button = QPushButton("Sipariş Ekle")
        add_button.clicked.connect(self.add_order)
        clear_button = QPushButton("Temizle")
        clear_button.clicked.connect(self.clear_order)
        save_button = QPushButton("Kaydet")
        save_button.clicked.connect(self.save_order)
        button_layout.addWidget(add_button)
        button_layout.addWidget(clear_button)
        button_layout.addWidget(save_button)

        # Düzenleme
        layout.addLayout(name_layout)
        layout.addLayout(phone_layout)
        layout.addLayout(address_layout)
        layout.addWidget(order_label)
        layout.addWidget(self.order_list)
        layout.addLayout(button_layout)

        self.setLayout(layout)

    def add_order(self):
        pass

    def clear_order(self):
        pass

    def save_order(self):
        pass

if __name__ == "__main__":
    app = QApplication([])
    window = PizzaOrderApp()
    window.show()
    app.exec_()
