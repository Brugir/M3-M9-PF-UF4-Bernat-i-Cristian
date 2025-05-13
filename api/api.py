from flask import Flask, jsonify
import json

app = Flask(__name__)

# Cargar el archivo JSON
with open("pokemon_clean_data.json", "r", encoding="utf-8") as f:
    pokemon_data = json.load(f)

# Endpoint para obtener todos los Pokémon
@app.route("/api/pokemon", methods=["GET"])
def get_all_pokemon():
    return jsonify(pokemon_data)

# Endpoint para obtener un Pokémon por nombre
@app.route("/api/pokemon/<name>", methods=["GET"])
def get_pokemon_by_name(name):
    result = next((p for p in pokemon_data if p["name"].lower() == name.lower()), None)
    if result:
        return jsonify(result)
    else:
        return jsonify({"error": "Pokémon no encontrado"}), 404

# Endpoint para obtener los Pokémon por tipo
@app.route("/api/tipo/<tipo>", methods=["GET"])
def get_pokemon_by_type(tipo):
    result = [p for p in pokemon_data if tipo.lower() in [t.lower() for t in p["types"]]]
    if result:
        return jsonify(result)
    else:
        return jsonify({"error": "No se encontraron Pokémon de este tipo"}), 404

# Endpoint para obtener los Pokémon por región
@app.route("/api/region/<region>", methods=["GET"])
def get_pokemon_by_region(region):
    result = [p for p in pokemon_data if p["region"].lower() == region.lower()]
    if result:
        return jsonify(result)
    else:
        return jsonify({"error": "No se encontraron Pokémon de esta región"}), 404

if __name__ == "__main__":
    app.run(debug=True)
