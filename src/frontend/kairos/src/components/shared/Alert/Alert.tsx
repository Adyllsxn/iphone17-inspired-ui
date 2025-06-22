import { useEffect, useState } from 'react';
import './Alert.module.css';

    type AlertProps = {
    message: string;
    type?: 'info' | 'success' | 'warning' | 'error';
    onClose?: () => void;
    };

    const Alert = ({ message, type = 'info', onClose }: AlertProps) => {
    const [visible, setVisible] = useState(true);

    useEffect(() => {
        const timer = setTimeout(() => {
        setVisible(false);
        if (onClose) onClose();
        }, 3000);

        return () => clearTimeout(timer);
    }, [onClose]);

    if (!visible || !message) return null;

    return (
        <div className={`customAlert ${type}`}>
            <span>{message}</span>
        </div>
    );
};

export default Alert;
