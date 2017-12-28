package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdDrgBunhoTest extends MessageRequestTest{
	@Test
	
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest request = DrgsServiceProto.DRG3010P10GrdDrgBunhoRequest.newBuilder()
				.setMagamDate("2013/10/3")
				.setMagamSer("8")
				.setMagamGubun("21")
				.setMagamBunryu("1")
				.setHoDong("T3")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
