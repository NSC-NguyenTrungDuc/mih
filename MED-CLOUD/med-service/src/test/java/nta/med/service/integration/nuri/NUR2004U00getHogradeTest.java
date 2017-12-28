package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00getHogradeTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00getHogradeRequest request = NuriServiceProto.NUR2004U00getHogradeRequest.newBuilder()
				.setToHoDong1("17")
				.setToHoCode1("T21")
				.setJunpyoDate("2016/12/10")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
