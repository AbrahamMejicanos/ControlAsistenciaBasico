import requests
import pandas as pd
import json
url="https://avnc.net/modules/wpcf_avnc/services/countries"

response=requests.request("GET",url)
ArchivoJson=response.json()
print(ArchivoJson[0])
print((ArchivoJson[0])['id'])