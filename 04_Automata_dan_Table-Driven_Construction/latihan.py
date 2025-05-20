from enum import Enum

class State(Enum):
    IDLE = "Idle"
    WAITING = "MenungguProduk"
    DISPENSING = "MengeluarkanProduk"
    DONE = "Selesai"

class VendingMachine:
    def __init__(self):
        self.state = State.IDLE

        # Definisi transisi FSM dalam dictionary
        self.transitions = {
            State.IDLE: { "Masukkan Uang": State.WAITING },
            State.WAITING: { "Pilih Produk": State.DISPENSING, "Reset": State.IDLE },
            State.DISPENSING: { "Keluarkan Produk": State.DONE },
            State.DONE: { "Reset": State.IDLE }
        }

    def trigger(self, action):
        if action in self.transitions[self.state]:
            self.state = self.transitions[self.state][action]
            print(f"Transisi ke: {self.state.value}")
        else:
            print("Aksi tidak valid!")

# Contoh Penggunaan
vm = VendingMachine()
vm.trigger("Masukkan Uang")
vm.trigger("Pilih Produk")
vm.trigger("Keluarkan Produk")
vm.trigger("Reset")