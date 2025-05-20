from enum import Enum

class jk(Enum):
    laki = 1
    perempuan = 2

pasien = []

def add_pasien(nama: str, gender: jk):
    if not isinstance(gender, jk):
        raise ValueError("gender harus Laki atau Perepuan")
    
    pasien.append({"nama": nama, "gender": gender.name})
    print(f"Berhasil menambahkan pasien {nama} dengan Jenis Kelamin {gender.name}")


add_pasien("Andi", jk.laki)
add_pasien("Susi", jk.perempuan)
add_pasien("Budi", "laki") # ValueError