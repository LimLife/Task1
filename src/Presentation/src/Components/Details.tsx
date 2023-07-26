import { useParams } from 'react-router-dom';
import Employees from './Employees';
import Notes from './Notes';
import Histories from './Histories';
import Companies from './Companies';


type URL = {
  id: string,
  name: string
}
const Details: React.FC = () =>
{
  const { id, name } = useParams<URL>();
  const idItem = id !== undefined ? parseInt(id) : Number.MAX_SAFE_INTEGER;
  console.log(`Params ${id}, name ${name}`)
  return (
    <div className='border-5'>
      <div className='padding-right-5'>Company Details : <span>{name}</span> </div>
      <div className='container-col-3-row-2 '>
        <div className='border-1-blanc'>
          <Companies id={idItem} />
        </div>
        <div className='border-1-blanc'>
          <Histories id={idItem} />
        </div>
        <div className='border-1-blanc'>
          <Notes id={idItem} />
        </div>
        <div className='border-1-blanc bottom-component'>
          <Employees id={idItem} />
        </div>
      </div>
    </div>
  );
};

export default Details;