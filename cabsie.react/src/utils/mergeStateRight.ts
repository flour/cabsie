const mergeStateRight = (a: any, b: any) => {
  if (a && b && typeof a === 'object' && typeof b === 'object') {
    return Object.entries(b).reduce(
      (obj, [key, value]) => {
        obj[key] = mergeStateRight(obj[key], value);
        return obj;
      },
      { ...a }
    );
  }
  return b;
};

export default mergeStateRight;
