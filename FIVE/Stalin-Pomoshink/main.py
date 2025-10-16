import socket
import requests
from openai import OpenAI

# Функция для принудительного использования определенного DNS
def set_custom_dns():
    # Эти DNS обычно работают с OpenAI
    dns_servers = [
        '83.220.169.155',
         '195.133.25.16'       
        
    ]
    
    # Создаем резолвер с кастомными DNS
    resolver = socket.getaddrinfo
    socket.getaddrinfo = lambda *args: resolver(args[0], args[1], socket.AF_INET)
    
    return dns_servers

# Использование в коде
set_custom_dns()

client = OpenAI(
    api_key="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"
)

try:
    response = client.chat.completions.create(
        model="gpt-3.5-turbo",
        messages=[{"role": "user", "content": "Привет!"}]
    )
    print("Успех!")
except Exception as e:
    print(f"Ошибка: {e}")