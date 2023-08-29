export default function Formulario(props: any) {

    return (
        <>
            <form style={{width:'40%'}}>
                <div className="form-group">
                    <input type="text" className="form-control" id="exampleInputEmail1" placeholder="Texto 1" />
                </div>
      <br />
                <div className="form-group">
                    <input type="text" className="form-control" id="exampleInputPassword1" placeholder="Texto 2" />
                </div>
      <br />
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        </>
    )
}