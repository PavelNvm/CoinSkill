import { Layout, Menu, Flex , Button } from "antd";
import "./globals.css";
import { Header } from "antd/es/layout/layout";
import Link from "next/link";

const items =[
  {key: "profile", label:<Link href={"/profile"}>Profile</Link>},
  {key: "leaderboard", label:<Link href={"/leaderboard"}>Leaderboard</Link>},
  {key: "chat", label:<Link href={"/chat"}>Chat</Link>},
  {key: "coinflip", label:<Link href={"/coinflip"}>Coinflip</Link>}
]

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Layout style={{minHeight:"100vh"}}>
          <Flex style={{background:"#E2DF83"}} gap="middle" align="start" justify="space-between" >
            <Flex align="start" justify="flex-start" style={{width:"1vw"}}>
            <Button style={{margin:"10px 5px 10px"}} type="text">Profile</Button>
              <Button style={{margin:"10px 5px 10px"}} type="text">Leaderboard</Button>  
              <Button style={{margin:"10px 5px 10px"}} type="text">Chat</Button>
            </Flex>   
            <Flex  align="start" justify="flex-center" >
              <Button style={{margin:"10px", fontSize:"20px"}} type="default" danger>Flip a coin</Button>             
            </Flex>
            <Flex  align="start" justify="flex-end"  style={{width:"1vw"}}>
              <Button style={{margin:"10px 5px 10px"}} type="text">Login</Button>
              <Button style={{margin:"10px 5px 10px"}} type="text">Sign in</Button>
            </Flex>
          </Flex>
          {children}</Layout>        
      </body>
    </html>
  );
}
