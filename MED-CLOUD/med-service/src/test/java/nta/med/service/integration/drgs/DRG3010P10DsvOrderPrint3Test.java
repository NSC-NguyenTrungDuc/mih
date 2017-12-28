package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3010P10DsvOrderPrint3Test extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3010P10DsvOrderPrint3Request request = DrgsServiceProto.DRG3010P10DsvOrderPrint3Request.newBuilder()
				.setSerialV("102")
				.setFkocs2003("11309119")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
