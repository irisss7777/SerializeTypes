# SerializeTypes

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

SerializeTypes is a small but powerful Unity plugin that allows you to serialize a type reference in the Inspector. Instead of storing a raw string or int identifier, you get a clean dropdown populated with all concrete subclasses of a given base type (T). Perfect for building modular, data‑driven architectures – for example, to define lists of service types, reaction types, or any polymorphic behaviour directly in ScriptableObject or MonoBehaviour fields.****

## ✨ Features
Type‑safe – store references to types that inherit from a specific base class.
Editor dropdown – powered by **[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)** – no custom inspectors required.
Cached reflection – the list of available types is built once per T and reused.
Seamless integration – works inside ScriptableObject, MonoBehaviour, or any serializable
