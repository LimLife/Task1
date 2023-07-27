import { REST } from "./Enums/REST";

async function Data<T>(api: string, state: REST): Promise<T | null>
{
    try
    {
        const response = await fetch(`http://localhost:5162${api}`,
            {
                method: state,
                headers: {
                    "Accept": "application/json",
                },
            }
        )
        if (!response.ok)
        {
            throw new Error(`Request failed with status code ${response.status}`);
        }
        return await response.json() as T;
    }
    catch {
        return null;
    }
};


export default Data;