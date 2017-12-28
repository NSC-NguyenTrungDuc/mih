package nta.med.service.integration.ocsi;

import org.junit.Test;
import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02ProcCreateSikjinTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception{
		OcsiServiceProto.OCS2005U02ProcCreateSikjinRequest request = OcsiServiceProto.OCS2005U02ProcCreateSikjinRequest.newBuilder()
				.setFromDate("2016/01/10")
				.setFromBld("1")
				.setBunho("000003227")
				.setMpressedJaewonYn("Y")
				.setUpdId("99999")
				.setUpdId("1")
				.setNomimono("2")
				.setSikjinGubun("1")
				.setSikgubun1Th("1")
				.setSikjong1Th("1")
				.setJusik1Th("1")
				.setBusik1Th("1")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}

}
