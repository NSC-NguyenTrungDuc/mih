package nta.med.service.integration.inps;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class INPORDERTRANSTest extends MessageRequestTest{
	@Test
	public void testSchsSCH0201U99ExecTimeListTest() throws InterruptedException {

//		InpsServiceProto.INPORDERTRANSSangTransRequest request = InpsServiceProto.INPORDERTRANSSangTransRequest.newBuilder()
//				.setFkINP3010("3475423")
//				.setTransGubun("N")
//				.build();
//		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
//		
		
//		InpsServiceProto.INPORDERTRANSIsJaewonPatientRequest request = InpsServiceProto.INPORDERTRANSIsJaewonPatientRequest.newBuilder()
//				.setBunho("000006677")
//				.build();
//		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
//		InpsServiceProto.INPORDERTRANSLayOut0101Request request = InpsServiceProto.INPORDERTRANSLayOut0101Request.newBuilder()
//				.setBunho("000006677")
//				.build();
//		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
//		InpsServiceProto.INPORDERTRANSGrdWoiChulRequest request = InpsServiceProto.INPORDERTRANSGrdWoiChulRequest.newBuilder()
//				.setBunho("000006677")
//				.setOrderDate("2017/04/13")
//				.setPk1001("1541")
//				.setSendYn("N")
//				.build();
//		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
		
//		InpsServiceProto.INPORDERTRANSGrdOutSangRequest request = InpsServiceProto.INPORDERTRANSGrdOutSangRequest.newBuilder()
//				.setBunho("000000011")
//				.setIoGubun("O")
//				.setGijunDate("2017/01/01")
//				.build();
//		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

		InpsServiceProto.INPORDERTRANSGrdWoiChul2Request request = InpsServiceProto.INPORDERTRANSGrdWoiChul2Request.newBuilder()
				.setBunho("000006677")
				.setOffset("200")
				.setPageNumber("1")
				.setSendYn("N")
				.setYmdFirst("2016/11/17")
				.setYmdLast("2016/11/17")
				.build();
		sentRequestToMedApp(request, InpsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));

	}
}
