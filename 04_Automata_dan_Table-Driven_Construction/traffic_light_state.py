from enum import Enum

class TrafficLight(Enum):
    MERAH = "Merah"
    HIJAU = "Hijau" 
    KUNING = "Kuning"

state_transitions = {
    TrafficLight.MERAH: TrafficLight.HIJAU,
    TrafficLight.HIJAU: TrafficLight.KUNING,
    TrafficLight.KUNING: TrafficLight.MERAH
}

state_duration = {
    TrafficLight.MERAH: 5,
    TrafficLight.HIJAU: 10,
    TrafficLight.KUNING: 2
}

# curent_state = TrafficLight.MERAH
# next_state = state_transitions[curent_state]
# print(f"State sekarang: {curent_state.value}")

while True:
    curent_state # type: ignore