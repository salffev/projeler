import discord
from discord.ext import commands

# Discord botunuzun token'ını buraya ekleyin
TOKEN = 'BOT_TOKEN'

# Botunuzun prefix'ini buraya ekleyin
bot_prefix = '!'

# Bot oluşturun
bot = commands.Bot(command_prefix=bot_prefix)

# Bot hazır olduğunda çalışacak kod
@bot.event
async def on_ready():
    print(f'Logged in as {bot.user.name} ({bot.user.id})')
    print('Bot is ready to save server data!')

# !save komutu ile sunucu verilerini kaydetme
@bot.command(name='save')
async def save_server_data(ctx):
    server = ctx.guild  # Sunucuyu al

    # Sunucu verilerini metin dosyasına kaydetme
    with open('server_data.txt', 'w') as file:
        file.write(f"Sunucu Adı: {server.name}\n")
        file.write(f"Sunucu ID: {server.id}\n")
        file.write(f"Üye Sayısı: {server.member_count}\n")
        file.write(f"Sunucu Sahibi: {server.owner.display_name} ({server.owner.id})\n")
        file.write("Kanallar:\n")
        for channel in server.channels:
            file.write(f"- {channel.name} ({channel.id})\n")
        file.write("Roller:\n")
        for role in server.roles:
            file.write(f"- {role.name} ({role.id})\n")

    await ctx.send("Sunucu verileri başarıyla kaydedildi!")

# Bot'u çalıştırma
bot.run(TOKEN)
