export interface IDictionary<TKey, TValue> {
  addEntry(key: TKey, value: TValue) : void;
  removeEntry(key: TKey) : void;
  getByKey(key: TKey) : TValue;
  getKeys() : TKey[];
  getValues(): TValue[];
}

export class Dictionary<TKey, TValue> implements IDictionary<TKey, TValue> {
  private readonly _keys: TKey[];
  private readonly _values: TValue[];
  private _entries: { key: TKey, value: TValue}[];

  constructor(init?: any[]) {
    this._entries = [];
    this._values = [];
    this._keys =[];
    if(init !== null) {
      init.forEach(e => {
        if(e.key !== undefined && e.value !== undefined) {
          this._keys.push(e.key);
          this._values.push(e.value);
          this._entries.push({ key: e.key, value: e.value });
        }
      });
    }
  }

  addEntry(key: TKey, value: TValue): void {
    let existing: boolean = this._keys.includes(key);
    if(!existing) {
      let entry = { key, value };
      this._keys.push(key);
      this._values.push(value);
      this._entries.push(entry);
    }
  }

  getByKey(key: TKey): TValue {
    let entry = this._entries.find(e => e.key === key);
    return entry?.value;
  }

  getKeys(): TKey[] {
    return this._keys;
  }

  getValues(): TValue[] {
    return this._values;
  }

  removeEntry(key: TKey): void {
    let index = this._entries.findIndex(e => e.key === key);
    if(index >= 0) {
      this._entries.splice(index, 1);
    }
  }
}
