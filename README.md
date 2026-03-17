# SerializeTypes

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

SerializeTypes is a small but powerful Unity plugin that allows you to serialize a type reference in the Inspector. Instead of storing a raw string or int identifier, you get a clean dropdown populated with all concrete subclasses of a given base type (T). Perfect for building modular, data‑driven architectures – for example, to define lists of service types, reaction types, or any polymorphic behaviour directly in ScriptableObject or MonoBehaviour fields.****

## ✨ Features
- **Type‑safe** – store references to types that inherit from a specific base class.
- **Editor dropdown** – powered by **[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)** – no custom inspectors required.
- **Cached reflection** – the list of available types is built once per T and reused.
- **Seamless integration** – works inside ScriptableObject, MonoBehaviour, or any serializable


## 📦 How to Use
1. Define a base class or interface****

```csharp
// Example: an abstract base class for all enemy reactions
public abstract class AEnemyReaction
{
    public abstract void React();
}

// Concrete implementations
public class StunEnemyReaction : AEnemyReaction
{
    public override void React() => Debug.Log("Enemy stunned!");
}

public class DamageEnemyReaction : AEnemyReaction
{
    public override void React() => Debug.Log("Enemy damaged!");
}
```

2. Use SerializeType<T> in your data container

```csharp
using System;
using Plugins.SerializeTypes;

[Serializable]
public class ReactionQueueData
{
    public SerializeType<AEnemyReaction> Reaction;   // ← dropdown appears here
    public float Time;
}
```
3. Create an instance of the selected type at runtime

```csharp
ReactionQueueData data = ...;
Type selectedType = data.Reaction.GetDataType();
if (selectedType != null)
{
    AEnemyReaction reaction = (AEnemyReaction)Activator.CreateInstance(selectedType);
    reaction.React();
}
```

4. Using inside a ScriptableObject

```csharp
[CreateAssetMenu(menuName = "Game/Reaction Set")]
public class ReactionSet : ScriptableObject
{
    public List<SerializeType<AEnemyReaction>> availableReactions;
}
```
