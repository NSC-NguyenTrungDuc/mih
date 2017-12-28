package nta.med.service.integration.ocsi;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OCS1024U00Test extends MessageRequestTest {

	@Test
	public void test() throws Exception {

//		OcsiServiceProto.OCS1024U00ApplySangOrderInfoRequest request = OcsiServiceProto.OCS1024U00ApplySangOrderInfoRequest.newBuilder()
//				.setOrdDanui("000")
//				.build();
		
//		OcsiServiceProto.OCS1024U00GetPkInp1001Order2Request request = OcsiServiceProto.OCS1024U00GetPkInp1001Order2Request.newBuilder()
//				.setBunho("000048256")
//				.build();
		
//		OcsiServiceProto.OCS1024U00GetPkInp1001Order1Request  request = OcsiServiceProto.OCS1024U00GetPkInp1001Order1Request.newBuilder()
//				.setBunho("000000011")
//				.setJaewonFlg("T")
//				.build();
//		OcsiServiceProto.OCS1024U00getBogyongNameRequest  request = OcsiServiceProto.OCS1024U00getBogyongNameRequest.newBuilder()
//				.setBogyongCode("110001")
//				.build();
//		OcsiServiceProto.OCS1024U00getJusaNameRequest  request = OcsiServiceProto.OCS1024U00getJusaNameRequest.newBuilder()
//				.setJusaCode("0")
//				.build();
//		OcsiServiceProto.OCS1024U00ValidationCheckRequest  request = OcsiServiceProto.OCS1024U00ValidationCheckRequest.newBuilder()
//				.setBogyongCode("110001")
//				.build();
//		OcsiServiceProto.OCS1024U00isDonbokYNRequest  request = OcsiServiceProto.OCS1024U00isDonbokYNRequest.newBuilder()
//				.setBogyongCode("110001")
//				.build();
//		OcsiServiceProto.OCS1024U00grdOCS1024Request  request = OcsiServiceProto.OCS1024U00grdOCS1024Request.newBuilder()
//				.setBunho("000000111")
//				.build();
		OcsiServiceProto.OCS1024U00grdOCS1024JusaRequest  request = OcsiServiceProto.OCS1024U00grdOCS1024JusaRequest.newBuilder()
				.setBunho("000000111")
				.build();
		sentRequestToMedApp(request, OcsiServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
