// Clase 83: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25926740#overview
import { MapContainer, TileLayer } from "react-leaflet";
import icon from 'leaflet/dist/images/marker-icon.png'
import iconShadow from 'leaflet/dist/images/marker-shadow.png'
import 'leaflet/dist/leaflet.css'
import L from "leaflet";

let DefaultIcon = L.icon({
    iconUrl: icon,
    shadowUrl: iconShadow,
    iconAnchor: [16, 37]
})

L.Marker.prototype.options.icon = DefaultIcon;

export default function LeafletMap(props: mapProps) {
    return (
        <MapContainer
            center={[-34.90783547400955, -56.192392002849544]}
            zoom={14}
            style={{ height: props.height }}
        >
            <TileLayer
                attribution="React películas"
                url="https://tile.openstreetmap.org/{z}/{x}/{y}.png"
            />
        </MapContainer>
    )
}

interface mapProps {
    height: string;
}

LeafletMap.defaultProps = {
    height: '500px'
}