package nta.med.service.integration.ihis;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CommonModelProto.LoadSearchOrder1RequestInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;                                                                               
                   
public class LoadSearchOrder1Test extends MessageRequestTest{                                                                                        
	
	@Test                                                                                                                  
	public void Test() throws InterruptedException {                                    
		LoadSearchOrder1RequestInfo info = LoadSearchOrder1RequestInfo
				.newBuilder()
				.setSearchWord("\345\244\247\345\241\232")
				.setGijunDate("2016/01/12")
				.setInputTab("03")
				.setWonnaeDrgYn("Y")
				.setPageNumber("1")
				.setOffset("200")
				.build();
		
  		SystemServiceProto.LoadSearchOrder1Request request =SystemServiceProto.LoadSearchOrder1Request
					.newBuilder()                              
					.setInputInfo(info)
					.build();                                                                                                  

  		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));                                                       
		}                                                                                                                      
	}                                                                                                                          