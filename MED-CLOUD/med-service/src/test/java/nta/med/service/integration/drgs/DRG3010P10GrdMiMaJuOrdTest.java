package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdMiMaJuOrdTest extends MessageRequestTest{
	
	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P10GrdMiMaJuOrdRequest request = DrgsServiceProto.DRG3010P10GrdMiMaJuOrdRequest.newBuilder()
				.setOrderDate("2011/11/16")
				.setBunho("000026346")
				.setHopeDate("2011/11/16")
				.setHoDong("T")
				.setDoctor("0110098")
				.setMagamGubun("N")
				.setMagamBunryu("1")
				.setPageNumber("")
				.setOffset("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
