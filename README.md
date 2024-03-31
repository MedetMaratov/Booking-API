# Booking-API
This Web service based on RESTful API provides a complete suite of features for booking and room management, including the creation of rooms with various types and amenities, alongside integrated logging for event tracking, Redis caching for enhanced performance, and seamless integration with Swagger for efficient API design and testing

# Technologies
<ul>
  <li>ASP.NET Core</li>
  <li>PostrgeSQL</li>
  <li>Entity Framework Core</li>
  <Redis>
  <li>Swagger</li>
  <li>Serilog</li>
</ul>

# Endpoints
## Amenity
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/amenities</td>
    <td>GET</td>
    <td>Retrieve all amenities</td>
  </tr>
  <tr>
    <td>/api/v1/amenities/id</td>
    <td>GET</td>
    <td>Retrieve a specific amenity by ID</td>
  </tr>
  <tr>
    <td>/api/v1/amenities</td>
    <td>POST</td>
    <td>Create a new amenity</td>
  </tr>
  <tr>
    <td>/api/v1/amenities/id</td>
    <td>PUT</td>
    <td>Update a specific amenity by ID</td>
  </tr>
  <tr>
    <td>/api/v1/amenities/id</td>
    <td>DELETE</td>
    <td>Delete a specific amenity by ID</td>
  </tr>
</table>


## Hotel branch
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/hotel-branch</td>
    <td>GET</td>
    <td>Retrieve all hotel branches</td>
  </tr>
  <tr>
    <td>/api/v1/hotel-branch/{country}/{city}</td>
    <td>GET</td>
    <td>Retrieve hotel branches in a specific country and city</td>
  </tr>
  <tr>
    <td>/api/v1/hotel-branch</td>
    <td>POST</td>
    <td>Create a new hotel branch</td>
  </tr>
  <tr>
    <td>/api/v1/hotel-branch/id</td>
    <td>PUT</td>
    <td>Update a specific hotel branch by ID</td>
  </tr>
  <tr>
    <td>/api/v1/hotel-branch/id</td>
    <td>DELETE</td>
    <td>Delete a specific hotel branch by ID</td>
  </tr>
</table>

## Occupied rooms
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/occupied-room/check-in/{roomId}</td>
    <td>POST</td>
    <td>Check-in an occupied room</td>
  </tr>
  <tr>
    <td>/api/v1/occupied-room/check-out/{roomId}</td>
    <td>POST</td>
    <td>Check-out an occupied room</td>
  </tr>
</table>

## Reservations
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/reservations</td>
    <td>GET</td>
    <td>Retrieve all reservations</td>
  </tr>
   <tr>
    <td>/api/v1/reservations</td>
    <td>POST</td>
    <td>Create a new reservation</td>
  </tr>
</table>

## Room types
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/room-types</td>
    <td>GET</td>
    <td>Retrieve all room types</td>
  </tr>
  <tr>
    <td>/api/v1/room-types/{id}</td>
    <td>GET</td>
    <td>Retrieve a specific room type by ID</td>
  </tr>
  <tr>
    <td>/api/v1/room-types</td>
    <td>POST</td>
    <td>Create a new room type</td>
  </tr>
  <tr>
    <td>/api/v1/room-types/id</td>
    <td>PUT</td>
    <td>Update a specific room type by ID</td>
  </tr>
  <tr>
    <td>/api/v1/room-types/id</td>
    <td>DELETE</td>
    <td>Delete a specific room type by ID</td>
  </tr>
</table>


## Rooms
<table>
  <tr>
    <th>URL</th>
    <th>HTTP Method</th>
    <th>Description</th>
  </tr>
  <tr>
    <td>/api/v1/rooms</td>
    <td>GET</td>
    <td>Retrieve all rooms</td>
  </tr>
  <tr>
    <td>/api/v1/rooms</td>
    <td>POST</td>
    <td>Create a new room</td>
  </tr>
  <tr>
    <td>/api/v1/rooms/disable/{roomId}</td>
    <td>POST</td>
    <td>Disable a room by ID</td>
  </tr>
  <tr>
    <td>/api/v1/rooms/enable/{roomId}</td>
    <td>POST</td>
    <td>Enable a room by ID</td>
  </tr>
  <tr>
    <td>/api/v1/rooms/id</td>
    <td>PUT</td>
    <td>Update a specific room by ID</td>
  </tr>
  <tr>
    <td>/api/v1/rooms/id</td>
    <td>DELETE</td>
    <td>Delete a specific room by ID</td>
  </tr>
</table>

