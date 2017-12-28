package nta.med.service.integration.ocsa;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

import org.junit.Test;

public class OCS0103U00GrdOCS0108Test extends MessageRequestTest{
	@Test
	public void testXRT9001R03Lay9003RRequest() throws InterruptedException {
		OcsaServiceProto.OCS0103U00GrdOCS0108Request request = OcsaServiceProto.OCS0103U00GrdOCS0108Request
			.newBuilder()
			.setHangmogCode("G009000002")
			.setHangmogStartDate("2012/04/01")
			.setHospCode("K01")
			.build();
	sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
