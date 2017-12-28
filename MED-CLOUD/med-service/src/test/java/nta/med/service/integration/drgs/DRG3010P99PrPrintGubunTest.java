package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P99PrPrintGubunTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P99PrPrintGubunRequest request = DrgsServiceProto.DRG3010P99PrPrintGubunRequest.newBuilder()
				.setDrgBunho("3008")
				.setJubsuDate("2017/01/04")
				.setPrintGubun("")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
