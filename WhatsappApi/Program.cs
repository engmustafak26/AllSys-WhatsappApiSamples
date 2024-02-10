using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WhatsappApi.Dto;
using WhatsappApi.Dto.Requests;
using WhatsappApi.Dto.Responses;



namespace WhatsappApi
{
    public class Program
    {
        const string Url = "https://www.sys-all.com/api";
        const string ApiKey = "Your Api Key";
        // you can use this online site https://codebeautify.org/image-to-base64-converter
        const string Base64Image = "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxISEhISEBIVFRUVFRUVFRUVFRUXFRUVFRUWFxUVFRUYHSggGBolGxUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGxAQGy0lIB8uLS8tLy8tLS01Ly0tLS0tLS0vLS0tLS0tLS0tLS0tLS0tKy0tLS0tLS0tLS0tLS0tLf/AABEIAR8AsAMBIgACEQEDEQH/xAAcAAABBQEBAQAAAAAAAAAAAAADAgQFBgcBAAj/xABFEAACAQICBwMIBggGAgMAAAABAgMAEQQhBQYSMUFRYRMicQcycoGRobHBFCNCUnPRJDNigpKys/BDg6LC0uElNBVTY//EABoBAAIDAQEAAAAAAAAAAAAAAAECAAMEBQb/xAAtEQACAgEEAgEDAwMFAAAAAAAAAQIDEQQSITEFQVETFCIyYXGBobEVNFKRwf/aAAwDAQACEQMRAD8Az9RRFpKiiKKtEFKKIK4BS1FQh0ClqK4FogFTJDwFLArwFKAqZIeFLArwFKAo5AeFdAroFdtUAcFdpVq6FqEEV6l2rmzUIIIrlqJs1wiiAHauEUS1cK1CAyKSwopFJIqEIZRRFFeUURRSjnlFEUV5VoqrUIcApYFFw2HaRlSNSzMbKoFyTyAqa1c1WkxcksYdIzFs7e1mw2iwtsDPepzNgeBNDJMEEBS1FX9/JqEUs+KvYE2WHkL7y9UL6RF+2fWB/tohweApYFJGLi+7J/Ev/GjRzxfdk9qVCYEhaUBTxewtfZl/iT8q9tQfdl/jj/40RRqBXgKdbUP3Zf40/wCNe2ouAceLD5JRINrV61OdiP79v3WPvAFO8PovtPMkX97u/OoAi7Vy1PMXgWjNmseq5r/Fa1+lN9moACVrhWjFaSVqEAkUlhRmWkEVCEOq0VVriiiqtKOeUUQCvKKKBUIT3k+X/wAjhvGX+hJUp5ERebSB/AO9jvae+RNhuG6o/UAf+Qw/jJ/RkqS8iP6zSH+R/NiKWXYyNJ0gO4/oN8DXzuJBYd0bh8K+isZ5reifhXzrs7vAUyRG8Bo2U/Z99OowvKmiCnUIo4E3DrhXEXOlKKUgzpgBo4U+0aII4eNzQrV61EGQ94R9g+2pjRhU+ath/fOoECp/Qy5CigZEKB2z3AyBF7k8Opt7qr7rVjA+tk8D8KgJBnQYQBFcIopFcIpSASKRajkUgijghDqtFUVwCiKtIOdVaIoriiiqKhCe1BH6fh/GT+jJUh5FP1ukf8j+aemWoI/T8P4yf0ZKsHkm0RJC+NeSw7Qx7I6KZTe/727pSvsZF5xW5vA/CvngjdlwFfRzw3rIZdTCLfWC/G4yt48/+91NEmG+ioxincQp3pPAwQggYhZJAbBEW/jtMDZeOW+oaXFOPNsPeadI20eL1Fy3JcEytLjFQMeNm3bQ/hX8qdQ6RkHnKreF1Pzp1Fvoun4TUpZSyTAFd2aVoiVJ27Mt2bnNQ2YYAXNmHEZ5W3C/O0njtGLEjO8qgDhY3J5Ab70HFp4OdPS2xnsceSMVan9DLUNouPthdSoscwzAWzyPUWq1aL0ey8R6jU6eGJZTOEtslhkay/WyeHyqvyDOrXicG6u7EZEHP1VV3GZoFbTQK1JIotqSRUACK0kiikUk1CEOoogFcUURRVZYdUUVRSVFEUUUBk/qH/7+H8ZP6MlPdU9f8Dhu2SeVhYjZ2Y5Hvm1x3V37t/Smeo4/ToP8z+jJWWRaN2ztX7o2r9Tcgj1WpJJt8GjTVu17IrLPqrBaSjmijmjJKSIrqSCDssARcHMZGsJ1t002Ifiqi4C3tv3k252GVadqXidrAYVVFtmFVtx7o2flWKadYq7i25mHsYina2QcjueJohGc3YuUNJcUFFhlTGTSIppPtSA7O8f37aWsKMqkkqwFiDuNULL5NF2tslLbWiQwmlhut+Zp5HpFG3HP+8qrcsXKhqCuY/vf+dWxtlHhCLyV9awW7BaYsVlS21GdoX3ZbwehFx66d4nWRsQwLkC3mqL7KjoCao/0kpGVBuWtc8ABwH59Kd6Ma6liQLVYr5bshq8grLlJrlIumAx3Zur52HnbJsSp84A+FWPQ/lIwcdwe1UcO6Tbdl3fXyqgaOxV9jxX4jKt+wcCA5IvsFPbPfhoz+asrlOM0u0VjF604Z9m7W7Qdy438sxexz3G1QL7zWr6XgX6LN3V8xuA5VlDCqoZ9nAtnuEkUkil16nKQRFIIoxpDCoQhwKIgpKiiKKrLBYFEApIFLAoik9qOP06D/M/pSVmejsaI1cP5hlkFx9k3PDlWmak/+7h/F/6T1k7/AKtvxn+dDc4yyaNNfKie+PaNy1Na2Ew9uKEg8xtHMdN1ZbpHEK880Ugse2kUG9h55Avy8a2LUFA2jMICL2iFs7W8DWP666BmgxUzMvdeR3UixyZieHK9POTxwdrx+rc5yl8kfiNDvA3m36MN/wAj6qSZYPtx7J6XqS0RrDZRFN3lHmki5XkDzFPMZDC/eUAjiBw6jpTQrUl+DOxGMWsxKxiJMMBcBieQy95qJmxC3yQe0n51YdIYRBuUf9HdURJsA/q19rfnSyplk5eqUs+kM4YTKbLHfwLe/OvYqyWjBuQcyD3b8QOfiaNPjntsjujkosPdvpjh12nUdaqksHNkkmku2WbVvDF8Rhox9qWMeraBPuBr6EimC7F97uqKOJJzNvBQzHopr5xGIaORGRtlwQykb1IzB9tbD5JtJNjhPi8Q4adX7BYxksEVlbuLwLte7cdgDhanT4F8hLMlH4RoOnMsJN6B+FZM1axrCf0Sb0DWUGjD2c2QmuEUqvUwogikkUQik1CEMooiikqKItVocWopYFJWiAUwCW1VfZxcB5M3vRh86ys/qm/Gb51o+DkKOrDeM/cazhj9W/4z0khon0F5ND/47C/hika04FJZMOrqDtyvHnyMMrmx8YkP7opXkxI/+Pwt+Kge/wDv2UrWKUfTNGrxOImP8OExA/3Ud+DRpZOLbRmmtWpTRktECw35DvgdQPOHhnVLM0kRz3c+FfQJIZnI3LfPgLf2ap2tGrkU20yjZNt9vOP7Q/s1dh9o9FCbseOmZacfffTSZ7080xoSSEnLIZnlbxqHD1HY/ZjvsnF7ZnpaPoaK73P2Rf5U3Y0QyNFtIN587p+z+f8A1VMuzHvSmmwjPeQm98/dwqe1e03Lo3GxYiO/ZyAdqn2XS9nHiCLg8DVewS3NXPXLRRXCaIFu/KMSetmki2Pcw9tCfCMeoll5N/1jcHByEbiot6yKywitN1gXZwJHJEHwFZmaeHRmkzlq4RSq4acUTSSKXXDUIQy0UUNaKKqQ4paIKQtEWmIK5+B+FZ6fMk/GetCNZ8R3JPx2oMMTbdTsd2OjtHOTZdvvejsS39l7+qorXnTfY4iGYZ/Ry7euSCWO/wDFJEPbUlqpgjNoiBFIDhQyX3bQvk3QgkHxqkax4KVY4o5wQ7Qyxna33WUmK5+1kIs+NYrbXXLnpltVqi8M0DViW+EiLG5ZdtzvLHeff8hTXF4zbvs7gczvF/ujmRxPDxvalam6f2sNJAzWZVIGe5Tk1vZVixOLCRgKQCbgdAN58Ru9VdWDTWT0lUVu3/JWNYpwGkJzFtgDmbXYH3e+s/xmH2DluNWLSeN22b7o7q/En3D3VC6Qe4pJyTQms2zTfwBwSZPId0YBHVzcqPYrn92ma9al8ZF2cEScWDTP++NlB6kH+s1Ex2FiazQkm2zgxnukyyal6EOKmC3CRr35ZGICxRjzmYndyHWtBjKaZ0rCMOP0LR6oAxy27G4sP2iij0UJ41jZxkhVkDEIxBKgkKxG4sONutFwwbgSOoNqWcym2WWfV+t5thH/AHf5hWZ1X9S8DiZIpJ3mnGHRlRQJZAkkmZItexCgcBvbfkasNXVvKKmctXKVXCKsAIrhpRrlQhDpRFoa0QVWhwi0RaQKIKJDtUAr9XL+O1aClVHA6a+jrP2UaiTt7K7AO0eZLspOQYjZAIUW73G1JZlLgKNb1Vxa4PR8Cy/rNi4j3MBnYsPsjxz6cKr+LxsOLJGIcm5PZiJLCNj9ppJO83sA6Uy0HMz4ZXdizOrMzE3JJvckmo7CCs0tF9RqU3yIyD1f0dLJiCgiIYMRcEqQoP2wbggDj0q+af1OkjhGzMDtLYqw3XGag8qQmkRChkkY7C5kX8632R47qRrHrkJRGAQoKKWPDbYC6qN7HOwArBq7NTVNRqZpjqL64bk+OipnVDEMkjgpZMyATmWIAAyzJNQ2ldGCNTe5YbxcAC+W0crkX8K2vRWBCosRvcXY34vY3v4Zisx15hMM6kfesRwKtkVI5EUlesv+qq7PZXZrLpcNkHo/SUUk4aaLbsjkR71Z1QlFtvK3AyqMmwLuzPIQpJJNxsi5PBQN3QCnGMwnZSh1vshytzvBB7yk+HtFLlw1mNzuNbXPb0VrPUUMvo6DddupFh6h+fspxo3Rz4iaOGMbTyMFRcszvNrkDcCd43U4giViq7QUEi7NkqjiTxt4Z1svkrwGjoNrscQs2IKXkbMAJtKLIpA7u0VzNzc787Ua8yfI/wBvb24vBK6U0LHgtHQYeLcjKC1gC7WO07AZbRNVGtJ1ywzSRRIu9pVW5vYbVwL2F+NULD6Nd77OzcEhVJs0hF7iMHzjlu6it8OhGhnXjUu2rs+wZBssAASF2i2aI4y2eTj2Gm8Gh5mzK7CmNpQzghWVBc2NuRp8oGGR1cNKUjO5tbfTb6WhYoL3BtmDyvv9VVQujOTivRZOmUIqT9katEWhrRVooUIKIKGKIKYgpazubfP+O1aKKzuffP8AjGpIKL/q1/6kfon50xwE6sSFIJG+l6M7Q6PXsfO2T7M7262qL1W0eWk22bYVee8nlsjM/DqKrnY00kjTVp4SqlZKWMdIf65oVigzPeLEjgAMlv1JDepeoo76GR4dH4pEH1LRtIAN6CQMz9SLG/TwpevYBhiIBsJcr8uyVbnqdi59VT+qN/okHo/M1njXvseS+1Z0MH+7LHgj30PC4z6H/o1n/lIgBxUKnIGRbnpcXNXmFlTZzAG0ABuFycgBVN8ryATxdQW9mVYddDbqoS/ZmGmh3WRgvbKvp/SaSF44lAiLliSM3YZBugyqHvXr04gwMr+ZFI3ooxHtAotuR7SminTxwsIb1Y9TNYUwLSylHaRljRNkqFCiZJJCwIuT9WtuG+/SHn0ZOgu8MijmUaw8TbKmlTmLLZRhbFx7Rt2jPKFHiElEeHKiFojEH7w3XBYhsiCrZDpvzs1wOnWi2fq432HZ0LBroXttWIIyyG+q9qhowx4AzsM5p7L6EaEfzFqd11aOYZZ4zXKEL5Rr6RYIda5FCgRR93ZN/rASVUKCbNnkooTaxt2bxrDEocMDbbuNtdkkXblUJXqt2oybmRONwruZVcERnZIYHMbOy27ecxutnQMI7PKrFXCi4BdSCRnmbjLM7qnDSTSRqUevbyPKxyxn0sEMtEWhCirRAFFEFDWliiQWtZ7ismnHOYmtCWs/xh7834hqq6Tiskzguer2LK4WPu37p4+NM9Faegv37p4jL2inOhlH0VLcUPzqoOvOq3dJAri7LFBey162aThmjjihfbbbB7u7cRa/O5FXXRGG7KGOP7qAHxtn771jwNXTyeY9mkkieW4CAqjG535lb8uXWkou3Wcrs7+u0Sr0yUZcR/yw+m9MM2kMPCMkikW/7TMN/qB+NNPKtitvHFeCRovrI2j8RTXWXuaSB/biPwFK8pcRGPkJ+0kTDw2APkax6jm3L9ZNOjqgrK2v+I/8m6QP2ivGplWzKzC52N2V+R+NaRCLbqwrRmPeCVJYzmp3cxxU9CK1LHa54eKFJQdtnUFYxvz+992xrfprY7MP0Y/J6S13ZjlqRZ8VjYoY2knYKgGZbj0A4npWI45UxeMYYSLYWaQCNPSNr24c7cKRpzTk2LfbmbIeag81fAc+taR5ItUipGNnWxI+pU7wDvkI5kZCqpz+tLbFcI0VU/YVOyb/ACfSLDrRo9cNg8JAm6Pu+JC5n1mqjV48oZ7sA6v8FqjXrdBYiecm222zteNerhpxDhrhNdpNQhCrRRQkNFWqxwq0RaGlclnVASxAsOJo5wFRbeELlxCpm7ADqaoWNa7ysNxckHpT1klnYsFZrn1Dp0prKhUlWFiN4NYLr3L1wd2nxNTWJT/L4+C16HlUYRCSB3DvNuJqrQYjebZ+71V2HDO3mKSByGQ9dMpMVyHtqtzb6RRPx+mo5ts/ohy2dhuoOExzwTLLGSGRgcuIB7y+BGVCgxfA7+B/vdQn99NHK5OfqdTGWIVLEV/cuOt2JD4mKZcg8cLjO9s7kerdVk8rOFGzhJxvMYQ9RYEfOonQOgjiBgXcHs0gBa/2rOdlR0+VOPKVp2ObssNHn2Q77cNrgo8Ko1UJb4y/f/w6tFk7JUxq7iuf4KPXq6B/fGtD1M1OC7M+KW7b0jO5ercz0pq6nN4R29VqoaeO6QjUPUntCuIxa2XIpEftcmcculbLgRa1qhcNU3gq6cK1COEeT1OqnqJbpf0Kz5RT+oHpn+SqVVw8ord+EfsP8Vqn1ZHoxPs7euGu1ymAcNcrppJqEIRaHi2lA+qAJ433+qlpRVNVNZRdB7ZZxkrmJxWI3OWHuHuoGGwzSsFFzfeTnYcTercKIgqj7fL5Z1V5VRhiMEn8ncNCEUKu4CkNFB2ZMnZ3uc22b7zzqP0/iiFEaX2m32vew8KhsLoiaTMRkC+ZOVue+hfZj8UhdHpd6ds54yaDoPQ0UuGXsW2AdoZd5d5BsOFZ9i9UcWt7IJBci6MOHGxsRWp6qoFgVBuUkUiMWZh+03xNW/SjJLJzLorczFsTgJEvtxSLaxO0jrYHcTcZUvCYUyZG6qLDtCDsoCQO8eWeVbpGTSptnYbbtsWJYEDZsN9wd9D7dL2Vxisld1i0quEwsccLAsyBIyN2yBYvWZMd5J6k050hMHkcoCE2m2F4KpNwAOA6VP4nVcw4E4iX9YxFl+4vXqawam/Lz66PUV7PH6fL/Uye1K1YVFTETAM7AMi7wgO4+l8KnNYNN/RzAg8+WVF8E2htH5euuat4oHBQSMQAIxcnoM6pGuumlnkiaIECMkBuZuuY9lbXKNVawcWux6q/Nj7z/g17CyrtBbjattW47IIF7crke2p/BVmXk8LNLO7XI2FBY53YtcC/gD7K07BVbGe+GTIineURvroxyjv7WP5VU6smv7/pQHKJPi9VqrI9Fb7FVy9cvXqYB6kk10mkE1CEKpoimm6tRVNVlo4U0RTTdTRAaIoYUjG6REEfNmvsj1nM9KRI5CkqLkA2HM8qqhxLOSznvHLw6dKzaqe2PB1PE6ZXW/k+ESuA1gxEB+rc2OZVhtD2HdU9o7WyNie2BQ7yQCQSTnYcKo0ExO0bWXnSQ7XHXhb51jrusgd7UaLTX84x/BsmjsWkqCSM3U8fCoHygaT7OEQqe9Lv6IN/tOVNPJ9jls8LNmW2kU8rZ2/KoTWB2xePMan7YiXoB5x+NbJ3bqk12zjUaJV6tqX6YcjnUzVkYkNLLcRgFUtkS/3gf2fjUxp3S4fCzYaY7OIittBsu0tltpzBGdW/AYRYo0jQWVQAPzqu6/6AWeEzqLSRDfxZOIPrqrUURjVz6MWp1D1FrlLr0UPB6XkkhTCXsiMSSOIvkD0o2m4dmOMj7x+FM9AxWaQ8re81YtZNFFcGszby6hByUg949Tw6eNZmnJ5+CvQf7mP8mj6paPEMEag3JAdmt5zMBf1AWAvwFXLAisgwvlIhiijVYZHZUVTcqq3AA3501i8quKWVpBEhUqFSMs2ymdyxt5zHKt7vrUcJmpeN1Em8RLJrvLfGy9FjX/Tf51V9JaQEQFhtO2SqN5P5VA6S1pmnxDTyBe8drYW4W4AA6m1qZR6TmLsy2LtlfZuQOS8qH3McYQ8fE2p5njH8nNITYgMDKXUnNRew9QFXLCM3Zpt+dsja8bZ1CaN0Y7MJcSSSPNUnd48vCpwtT0RazJ+yryF8JKNcUvx7aFk0gmklqQWrQcwhFaiq1FGCNEXBnlVeS3AIPRA1EXBmlfQzRyDAPbqvaTRRKeRsT+9e59oqxSwhc2IW+WZtQtYdDbcMEsFncxuroDcnYkcqcul/ZWfVLMMHS8bb9C3dLprBTsVEyKQM14Gh4XEFrXByzy+dERcQq7RicpzKtahR4wZgALffWTbJLlHa+tXKacJYXwTeqsv6VGWDEXY2U2tsgm56ZZ0rQGNVMZDLIe72t2PpXF/fUh5OoVeXEWzKYd9nxbI1Wqj/ABSY9eLpzi/hI+hY4wRcbqDpDDhopF5ow91Znqfrs2HAhxF3i3KwzeMf7lrT8Li45kDxOHUjepv7eVabpxtoljvB5zUaSzTzxJcfJk+puDRsfsSbhc7PAlQbAjlf+860jWHQYxcPYlineVtoC+6s3UnD6Uib/wDW3qbL51sS0uhanVgzRk4T3R7Kjo7yYYX/ABHlf1hfgKsGB8mujYwXaIvsgn6x2IyHIWqoa56Zx302HDYRXQhgY7bpWO8ngUGeVajjmdcI/aFdsxbJIyXbYWNr8LmrdteWkujfdbqIxjKU/wBX7mI4nRuHLsRGBnewvYeAo0MaJ5qgeApxjcLsyMBz+VA7I1fGEV0jnzuslxKTf9RZkrnaUnsjSWiNOVCjLSGkpJjNIaM1CFqXR45UsaOFTYhpYhFZdzOhsRCDR9JxGBIRiozCkjxAqwLDSxAKmWFQjkwjSONdzd2JPu8AKPq1plsPPG+8E2ZMxl5t+lrk1e9K+TpWJOGk2L3NnuwuTwNVXB4NMJMVlIYqSGe3H8hWRRlF8nS1WsqdW2K79fBoZxcLnuyIb8Cygn1Gjx6PjP8AhIf3FPyqsnS+HxP6OFV8ts3W4GyVGV+NyN3WnWEwex+qkmi9CRiP4ZNpR6hWuqU5rLWDhpllwmjYkYskSKxFiVUAkcjasY09gTBiJoj9lzbqpzU+w1q8c2LAsuKB/FgR/wCQpVZ100HiZx9IYxO6LZhHE0bMo42Ltcil1EHKPC6On4zUxqtxJ8Mz+nejtJTQNtQyMh42OR8RuNNbVyucenlCM1hrKJDG6WkllSVwNpWVrjK+yb1pGE8pOENttJVPogj2g1k9eqyq11cROfZ4rTzecY/g23D+UTRlwzu113ExMSL77Wpnp7yo4WQBIVkK3uWN0JtusACbeyser1W/dTKv9Gp+WXPFa1wszNsMSTfLIDlmTnUdNrSfsRAdWN/cKrtTOg9WcRiiOzSycZGyUeHP1VPuLJdBfjNLWt0/7sG2mMTKwVTYnIKi5/nVr0PoR0XamYtI2+5JCjkKsegtUosKMu853ud/gOQqVbA1fXlcyfJzNVKElsqikv8AJVWwNDbBVa2wFDbAVf8AVMC07JcRUoRU5GzzpQtzqrJfgbiKlCKnAtzpGJmWNC7HIcBvJ4AdSamQDTGSLGjO3Ae08AOZJrPYNFQyl+2HeZiWvcEE/CtChwRdllnIuM0jv3Y+v7TdfZWa+U2YR4iXZDBiiG4J2T3RvAI5Uk4Sn08Fdi4IfQmEWPHTRxttqqNZuffj+F7VcsKprIcDpOaJi0ThWKlfNF7Eg8Q3ECny6Z0i5sHYdQzD+UitMXhJMowbLhoidwvUlFo+U7kPsrHcLgsbLbbxYX03xJ/lY1P6O1cxQII0jAp6yYpf99PuJgs+mvJouIJeO8MhzJ2Tsseq/lVH0t5OtIwk/UGVfvRZ/wCk51r2qcGJjAE+JgmXmk0xYepyRVr7RfvD21kspjJ5OhR5K+lYzlfufKeJ0fNHlJDInpRsPiKEsDncjHwU19PaT0lhFB7SXDg/tul/eazXS+troWMMmBOZ2UCOxtwBbt1X4eFVrTJ+zfHzE2v0L/szrB6vYuX9XhpT12CB7WsKtOhvJZjJSO2ZIV6nab2D86ltG+UPFgDtsJhSPvLNKqgdSqSD31cdG66YeQhII3kc8nhCj+Nw5Hgt+lPHTQXZnt8tc+IpIr+i9QsJh2uwMzA+dJuy5KMqsioALCwA3AbhRzA2ZcANe5AvYX4C4B9orhiq+MYrpGGd1ljzJ5AEUhhRmShOopsIr3sGw60NvGlsBQWUUdqB9Rk2JRSg4qBXG0QY2qMGjJOBhXHRWtcXsQR4jdUOuNpX06phkyTVxVD8pmrTTgYiCxdV2XTiygkhl6i5FuItyqxHHVEaS0qL2O6hhoDw+GYsIGDWIzB3EA+45e2nTysgyiQ9dhPgFrRMZNh5P1sSv6Sg1HPorBN/hFfRZl/lNPuEUIlFXTMw83ZHo3HwNGj1kxY82Rh6yfiat51dwR/+z+Nj8aQdVsF95x6gfiKO8H038kforyi4uHegk9JV+UZPvqWk8rmJYWGHhHqY/wCylYTV/DIbxyup5hEv7dmnz6OVhY4iQjqif8aO5A+mytTa6Tub/R4CfQk+TAU+0fpbFzEBcHhn9KBW/nuafpoKFTcTyA8wkYP8lOlwy8cViiOXaWHuFTd8BUEuyc0IuIA+tw2BjbgBFHtE2yuqqNnPqfVVnbWOPBw/p8kCycI4Nolhwshz9e7rWfLhIM9p8Q4O8NiJiPZtWpxhMJgo/MwyXOdyNrPnnxqJAkl6LNDrPDMSyE58NmnQnvuPuqDw2kkA7qgeAAov/wAtRwyJok32ulAcP0pi2l6G2laPIG4jmRX5im7o/MUB9KUB9J0eRcwP/9k=";

        static void Main(string[] args)
        {
            // This code for .net core applications
            var sendToGroupResponseDotNetCore = DotNetCore_SendToGroupApi().Result;
            Console.WriteLine("Status: " + sendToGroupResponseDotNetCore.IsSuccess + " - Message: " + sendToGroupResponseDotNetCore.Message);

            //this code for .net framework applications
            var sendToGroupResponseDotNet = DotNet_SendToGroupApi();
            Console.WriteLine("Status: " + sendToGroupResponseDotNet.IsSuccess + " - Message: " + sendToGroupResponseDotNet.Message);

        }

        static async Task<BaseResponseDto<EmptyResponseDto>> DotNetCore_SendToGroupApi()
        {

#if NETCOREAPP2_0_OR_GREATER
            SendToGroupRequestDto requestDto = new SendToGroupRequestDto
            {
                GroupId = 4,//your group Id
                Message = "Test Message - رسالة تجربة", // your message
                Base64Image = Base64Image
            };
            string serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(new BaseRequestDto<SendToGroupRequestDto>(requestDto));

            var client = new System.Net.Http.HttpClient();
            var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, GenerateRequestUrl("Sender/SendToGroup"));
            request.Headers.Add("accept", "*/*");
            var content = new System.Net.Http.StringContent(serializedRequest, System.Text.Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseContent = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseDto<EmptyResponseDto>>(responseContent);
#endif
            return new BaseResponseDto<EmptyResponseDto>();

        }
        static BaseResponseDto<EmptyResponseDto> DotNet_SendToGroupApi()
        {

            SendToGroupRequestDto requestDto = new SendToGroupRequestDto
            {
                GroupId = 4,//your group Id
                Message = "Test Message - رسالة تجربة", // your message
                Base64Image = Base64Image
            };
            string serializedRequest = Newtonsoft.Json.JsonConvert.SerializeObject(new BaseRequestDto<SendToGroupRequestDto>(requestDto));


            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(serializedRequest);
            System.Net.HttpWebRequest httpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(GenerateRequestUrl("Sender/SendToGroup"));
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/json";
            httpRequest.ContentLength = bytes.Length;
            using (Stream stream = httpRequest.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
            }

            WebResponse webResponse = httpRequest.GetResponse();
            Console.WriteLine(((HttpWebResponse)webResponse).StatusDescription);
            var webData = webResponse.GetResponseStream();
            StreamReader reader = new StreamReader(webData);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            webData.Close();
            webResponse.Close();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<BaseResponseDto<EmptyResponseDto>>(responseFromServer);

        }

        static string GenerateRequestUrl(string endPoint)
        {
            return Url + "/" + endPoint + "?apikey=" + ApiKey;
        }
    }
}
