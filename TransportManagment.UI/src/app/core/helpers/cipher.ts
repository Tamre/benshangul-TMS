export function caesarCipherEncrypt(str:string, key:number):string {
    let result = '';

    for (let i = 0; i < str.length; i++) {
        let char = str[i];
        let code = str.charCodeAt(i);
        // Encrypt characters
        code = (code + key) % 65536; // 65536 is the number of characters in Unicode
        char = String.fromCharCode(code);
        result += char;
    }
    return result;
}

export function caesarCipherDecrypt(str:string, key:number):string {
    let result = '';

    for (let i = 0; i < str.length; i++) {
        let char = str[i];
        let code = str.charCodeAt(i);
        // Decrypt characters
        code = (code - key + 65536) % 65536; // 65536 is the number of characters in Unicode
        char = String.fromCharCode(code);
        result += char;
    }
    return result;
}
