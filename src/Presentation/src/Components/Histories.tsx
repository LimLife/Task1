import React, { useEffect, useState } from "react";
import History from "../Interfaces/History";
import Data from "../ReturnData";
import update from "../img/update.png";
import { REST } from "../Enums/REST";


const Histories: React.FC<{ id: number }> = ({ id }) =>
{
    const [history, setHistory] = useState<History[]>([]);
    const data = async () =>
    {
        const history = await Data<History[]>(`/company/storedate/${id}`, REST.GET)
        if (history !== null)
            setHistory(history);
    }
    useEffect(() =>
    {
        data();
    }, []);
    return (<>

        <div>
            <div className="row">
                <span className="text-col-bl-size-20" >History</span>
                <div className="item-right">
                    <button onClick={data} className="btn" title="update" type="button">
                        <img src={update} alt="check mark" width={20} height={20} />
                    </button>
                </div>
            </div>
            <div className="row">
                <span>Order Date:</span>
                <span>Store City:</span>
            </div>
            {history?.map(item =>
            (
                <dl className="row " key={item.id} >
                    <dt >{item.orderDate[0]}</dt>
                    <dd>{item.city}</dd>
                </dl>
            ))}
        </div>
    </>)
}

export default Histories;