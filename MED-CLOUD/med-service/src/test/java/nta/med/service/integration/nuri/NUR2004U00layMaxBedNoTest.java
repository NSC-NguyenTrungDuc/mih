package nta.med.service.integration.nuri;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class NUR2004U00layMaxBedNoTest extends MessageRequestTest {
	
	@Test
	public void test() throws Exception {
		
		NuriServiceProto.NUR2004U00layMaxBedNoRequest  request = NuriServiceProto.NUR2004U00layMaxBedNoRequest.newBuilder()
				.setHoDong("17")
				.setHoCodeYmd("2016/12/10")
				.build();
		sentRequestToMedApp(request, NuriServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
	
}
