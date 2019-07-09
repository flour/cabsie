// export function ActionCreator<TType extends string | {} | null | undefined>(
//   type: TType
// ) {
//   return { type };
// }

export type InferValuetypes<T> = T extends { [key: string]: infer U }
  ? U
  : never;

const appTypes: { [key: string]: boolean } = {};

export type BaseAction = {
  type: string;
  payload?: P;
  error?: Error;
};

export function createAction<P>(
  type: string,
  payloadCreator?: (...args: any[]) => P
): Function {
  if (appTypes.hasOwnProperty(type)) {
    throw new Error(`Action creator with type: '${type}' already defined`);
  }
  appTypes[type] = true;

  const creator = (...args: any): BaseAction => {
    const payload =
      typeof payloadCreator === 'function' ? payloadCreator(...args) : args[0];

    const action: BaseAction = {
      type,
      payload,
      error: payload instanceof Error ? (payload as Error) : undefined
    };
    return action;
  };
  creator.toString = () => type;
  creator.match = (action: BaseAction) => action && action.type === type;

  return creator;
}
