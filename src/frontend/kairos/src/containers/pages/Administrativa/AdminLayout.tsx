import { Outlet } from 'react-router-dom';
import './AdminLayout.css';
import Sidebar from '../../../components/shared/Sidebar/SideBar';

export default function AdminLayout() {
  return (
    <div className='layoutContainer'>
      
        <div className='administrativa-context'>
          <h1>Área Administrativa</h1>
          <p>
              Esta área é exclusiva para membros autorizados da equipe administrativa da igreja.
          </p>
      </div>

        <div className="admin-layout">
          <Sidebar />
          <main className="admin-content">
            <Outlet />
          </main>
        </div>
    </div>
    
  );
}
