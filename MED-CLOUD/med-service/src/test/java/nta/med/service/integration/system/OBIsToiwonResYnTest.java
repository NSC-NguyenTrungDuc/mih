package nta.med.service.integration.system;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OBIsToiwonResYnTest extends MessageRequestTest{

	@Test
	public void test() throws InterruptedException {

		SystemServiceProto.OBIsToiwonResYnRequest request = SystemServiceProto.OBIsToiwonResYnRequest.newBuilder()
				.setFkinp1001("1606663")
				.build(); 
		
		sentRequestToMedApp(request, SystemServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
