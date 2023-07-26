import React, { useEffect, useState } from "react";
import Note from "../Interfaces/Note"
import Data from "../ReturnData";
import update from "../img/update.png";
import trash from "../img/trash.png";
import plus from "../img/plus.png";
import { REST } from "../Enums/REST";


const Notes: React.FC<{ id: number }> = ({ id }) =>
{
    const [note, setNote] = useState<Note[]>([]);
    const data = async () =>
    {
        const note = await Data<Note[]>(`/company/orderemployee/${id}`, REST.GET)
        if (note !== null)
            setNote(note);
    }
    useEffect(() =>
    {
        data();
    }, []);
    return (
        <>
            <div>
                <div className="row">
                    <span className="text-col-bl-size-20">Note</span>
                    <div className="item-right">
                        <button className="btn" title="not add" type="button">
                            <img src={plus} alt="check mark" width={20} height={20} />
                        </button>
                        <button className="btn" title="delete employee" type="button">
                            <img src={trash} alt="check mark" width={20} height={20} />
                        </button>
                        <button className="btn" title="update" type="button">
                            <img src={update} alt="check mark" width={20} height={20} />
                        </button>
                    </div>
                </div>
            </div>
            <div>
                {note?.map(item =>
                (
                    <dl key={item.id} className="row">
                        <dt>{item?.fullName}</dt>
                        <dd>{item?.invoice[0]}</dd>
                    </dl>
                ))}
            </div>
        </>)
}
export default Notes;

