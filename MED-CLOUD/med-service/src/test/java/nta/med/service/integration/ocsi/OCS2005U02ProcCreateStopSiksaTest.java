package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS2005U02ProcCreateStopSiksaTest extends MessageRequestTest{
	@Test
	public void Test() throws Exception {
		OcsiServiceProto.OCS2005U02ProcCreateStopSiksaRequest request = OcsiServiceProto.OCS2005U02ProcCreateStopSiksaRequest.newBuilder()
				.setStopFromDate("2016/07/01")
				.setStopFromBld("1")
				.setStopToDate("2016/07/31")
				.setStopToBld("1")
				.setBunho("000003227")
				.setUpdId("99999")
				.setIudGubun("I")
				.setMpressedJaewonYn("Y")
				.setCommentGubun("")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
