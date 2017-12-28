package nta.med.service.integration.orca;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OcsCHTAPPROVEgrdAPP1001Test extends MessageRequestTest{

	@Test
	public void test () throws Exception{
		OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Request request = OcsaServiceProto.OcsCHTAPPROVEgrdAPP1001Request.newBuilder()
				.setOutsangYn("N")
				.setBunho("000010656")
				.setDoctor("0110323")
				.setIoGubun("I")
				.setApproveYn("Y")
				.setPrePostGubun("Y")
				.setAllSangYn("")
				.setGijunDate("")
				.build();
		sentRequestToMedApp(request, OcsaServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
