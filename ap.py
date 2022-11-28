import requests
import pandas as pd
import json
url="https://avnc.net/modules/wpcf_avnc/services/countries"

response=requests.request("GET",url)
ArchivoJson=response.json()
l=[]
for i in ArchivoJson:
    l.append(i)
df=pd.DataFrame(l)
df.to_json("archivo.json",orient='index')




