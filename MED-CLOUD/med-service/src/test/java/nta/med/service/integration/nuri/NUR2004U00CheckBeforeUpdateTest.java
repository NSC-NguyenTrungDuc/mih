package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00CheckBeforeUpdateTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00CheckBeforeUpdateRequest request = NuriServiceProto.NUR2004U00CheckBeforeUpdateRequest.newBuilder()
				.setFkinp1001("1612522")
				.setTransCnt("5")
				.setToHoDong1("T3")
				.setToHoCode1("T11")
				.setToGwa("T3")
				.setToDoctor("T310004")
				.setToBedNo("T3")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
