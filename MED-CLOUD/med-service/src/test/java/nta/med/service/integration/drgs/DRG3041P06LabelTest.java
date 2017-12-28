package nta.med.service.integration.drgs;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class DRG3041P06LabelTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		DrgsServiceProto.DRG3041P06LabelRequest request = DrgsServiceProto.DRG3041P06LabelRequest.newBuilder()
				.setJubsuDate("2011/11/18")
				.setDrgBunho("3006")
				.setRp("1")
				.setSeq("1")
				.build();
		sentRequestToMedApp(request, DrgsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
