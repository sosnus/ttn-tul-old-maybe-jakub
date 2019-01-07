function Decoder(bytes, port) {
  // Decode an uplink message from a buffer
  // (array) of bytes to an object of fields.
  var decoded = {sensorID:"",sensorPassword:"",Value:""};
  
  for (i=0;i<8;i++)
  {
    if (String.fromCharCode(bytes[i]) != "0")
    {
      decoded.sensorID += String.fromCharCode(bytes[i]);
    }
  }
  
  for (i=0;i<8;i++)
  {
    if (String.fromCharCode(bytes[8+i]) != "0")
    {
      decoded.sensorPassword += String.fromCharCode(bytes[8+i]);
    }
  }
  
  var flaga=0;
  
  for (i=0;i<32;i++)
  {
    if ((String.fromCharCode(bytes[16+i]) != "0") | (flaga === 1))
    {
      decoded.Value += String.fromCharCode(bytes[16+i]);
      flaga=1;
    }
    
  }

  return decoded;
}
