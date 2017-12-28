package nta.med.service.integration;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.junit.Test;

public class SyncKinkiMessageCacheTest extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
//		SystemServiceProto.OCS0150Q00GridOCS0150Info.Builder info = SystemServiceProto.OCS0150Q00GridOCS0150Info.newBuilder();
//		info.setCheckingDrugYn("Y");
		
		SystemServiceProto.SyncKinkiMessageCacheRequest request =SystemServiceProto.SyncKinkiMessageCacheRequest
				.newBuilder()   
				.setOffset("200")
				.setPageNumber("1")
				.build();    
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}

}
