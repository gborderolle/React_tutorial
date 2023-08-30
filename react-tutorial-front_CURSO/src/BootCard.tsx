export default function BootCard(props: propiedadesInterfazProps) {

    const imagenURL = "https://cdn.iconscout.com/icon/free/png-512/free-react-1-282599.png";

    return (
        <>
            <div className="card" style={{ width: '18rem', textAlign:'center' }}>
                <img className="card-img-top" alt="Logo React" src={imagenURL}></img>
                <div className="card-body">
                    <h5 className="card-title">{props.title}</h5>
                    <p className="card-text">{props.body}</p>
                    <a href="#" className="btn btn-primary">botón</a>
                </div>
            </div>
        </>
    )
}

interface propiedadesInterfazProps{
    title:string,
    body:string
}