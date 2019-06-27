export function createAction<TType extends string | {} | null | undefined>(
  type: TType
) {
  return { type };
}

export type InferValuetypes<T> = T extends { [key: string]: infer U }
  ? U
  : never;
