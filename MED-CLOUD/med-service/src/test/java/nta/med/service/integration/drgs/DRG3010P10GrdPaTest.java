package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10GrdPaTest extends MessageRequestTest {

	@Test
	public void Test() throws Exception {
		DrgsServiceProto.DRG3010P10GrdPaRequest request = DrgsServiceProto.DRG3010P10GrdPaRequest.newBuilder()
		        .setFromDate("2010/1/1")
		        .setToDate("2016/1/1")
		        .setBunho("000026346")
		        .setHoDong("T")
		        .setMagamGubun("N")
		        .setMagamBunryu("1")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
