import random
import time

battery_level = 100.0  # Başlangıçta tam dolu bir pil
charging_rate = 0.1   # Şarj hızı (örneğin, her mili saniyede artış miktarı)
discharging_rate = 0.05  # Deşarj hızı (örneğin, her mili saniyede azalma miktarı)

while True:
    # Pil seviyesini güncelleme (rastgele veri üretimi)
    battery_level += random.uniform(-discharging_rate, charging_rate)

    # Pil seviyesini 0 ile 100 arasında sınırlama
    battery_level = max(0, min(100, battery_level))

    # Pil seviyesini yazdırma
    print(f"Pil Doluluğu: {battery_level}%")

    # Bekleme süresi (örneğin, her mili saniye)
    time.sleep(0.001)
